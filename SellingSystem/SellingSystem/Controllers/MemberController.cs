using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using SellingSystem.Middleware;
using SellingSystem.Models.DB;
using SellingSystem.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SellingSystem.Models.DataModels.Selling_requestModel;
using ClassLibrary.NLog;


namespace SellingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MemberController : Controller
    {
        // Nlog setting
        private static Logger logger = LogManager.GetLogger("testrule");

        private readonly ILogger<MemberController> _logger; // 這樣的用法 好處是 不需要在每頁都去宣告上面那行 "private static Logger logger = LogManager.GetLogger("testrule");"
        // 或是這樣 "private static Logger logger = NLog.LogManager.GetCurrentClassLogger();"



        private IMemberServicers _memberServicers;
        private IMathematics _mathematics;

        public MemberController(ILogger<MemberController> logger, IMemberServicers memberServicers, IMathematics mathematics )
        {
            _memberServicers = memberServicers;
            _mathematics = mathematics;
            _logger = logger;
        }

        //[Route("~/")]
        //[Route("action")]
        [Route("~/Member")]
        public string Index()
        {
            // put an item in the log
            logger.Info("Entering the login controller. Login method");
            NLogHelper.Info("Testing NLogHelper in ClassLibrary!!");

            var one = 3;
            if (one > 4)
            {
                logger.Info("it is true");
            }
            else
            {
                _logger.LogInformation("it is false");
                return "false";
            }

            return "this is default Action";
        }

        [TypeFilter(typeof(ActionFilter))]
        public string LoginMember([FromQuery]string username, int password)
        {
            // login success 
            return "login success";
        }

        //[HttpGet]
        //public bool test()
        //{
        //     return _memberServicers.CheckTheMember("test", 123);
        //}

        //[HttpGet]
        //public bool test1()
        //{
        //    return new MemberServicers().CheckTheMember("test", 123);
        //}

        //[HttpGet("{uniqueId}")]
        [Route("{uniqueId}")]
        public string LaunchTransaction(string uniqueId, [FromQuery]string Data) // the data is transactionData but Encrypted
        {
            // we need to get the member's IV
            DataAccess dataAccess = new DataAccess();
            var listOfKeyIV = _mathematics.GetKeyIV(uniqueId);

            // Decrypt the cipherText (Data)
            // before decrypt the data first do UrlDecode
            //string UrlDecodeData = System.Web.HttpUtility.UrlDecode(Data);

            string response_decrypt = _mathematics.Decrypt(Data, listOfKeyIV[0].IV);
            TransactionData originalTransPlainText = JsonConvert.DeserializeObject<TransactionData>(response_decrypt);

            // check is the user have login
            bool loginResponse = _memberServicers.CheckLogin(originalTransPlainText.memberId);
            if (loginResponse == false)
            {
                return "Please login first";
            }
            else
            {
                //check the timeout
                bool timeOutResult = _memberServicers.CheckTimeOut(originalTransPlainText.memberId);
                if (timeOutResult == false)
                {
                    return "TIME OUT!! please login again..";
                }
                else
                {
                    if (originalTransPlainText.type == 0)
                    {
                        _mathematics.Deduction(originalTransPlainText.amount, originalTransPlainText.memberId);
                        return "Deduction is success";
                    }
                    else
                    {
                        
                        _mathematics.Deposit(originalTransPlainText.amount, originalTransPlainText.memberId);
                        return "Deposit is success";
                    }
                }
            }
        }

        // 測試 FromQuery 拿出的值 是否可以使用 model 的模型 ANS: YES
        [HttpGet]
        public string TestQueryString([FromQuery]KeyIV param)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"{param.uniqueId}, {param.IV}, {param.SecretKey}");
            return str.ToString();
        }
    }
}
