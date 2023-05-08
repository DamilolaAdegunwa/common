using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryApp
{
    public class Constants
    {
        public const string EmailRegEx = @"^([_a-zA-Z0-9-]+)(\.[_a-zA-Z0-9-]+)*@([a-zA-Z0-9-]+\.)+([a-zA-Z]{2,10})$";
        public const string NicknameRegex = @"^[a-zA-Z0-9_.]{1,15}$";
        public const string GenericMobileNumberRegex = @"^\d{10,13}$";
        public const string ReferralActivationStatus = "2";
        public const int RetryWebPaySingleCallTimeInSeconds = 60;
        public const string SensitiveDataKeys = "SensitiveDataKeys";
        public const string SensitiveDataDefaultValues = "pan,authorization,secret,cookie,refresh_token,refreshtoken,securedata,paymentmethodpan,pinblock,paycode,pin,token,password,access_token,currentpindata,newpindata,passportToken";
        public const string PhonePlaceHolder = "[[PhoneNumber]]";
        public const string EmailPlaceHolder = "[[Email]]";
        public const string TransferToAccountUssdCode = "*322*AccountNumber*Amount#";
        public const string RechargeSelfUssdCode = "*322*Amount#";
        public const string RechargeOthersUssdCode = "*322*MobileNo*Amount#";
        public const string LogstashHostPlaceHolder = "Logstash:Host";
        public const string LogstashPortPlaceHolder = "Logstash:Port";
        public const string LogstashTracePortPlaceHolder = "Logstash:TracePort";
        public const string TokenProviderPathPlaceHolder = "TokenProvider:Path";
        public const string TokenProviderAudiencePlaceHolder = "TokenProvider:Audience";
        public const string TokenProviderIssuerPlaceholder = "TokenProvider:Issuer";
        public const string EAccountStatementRequestDateFormat = "yyyy-MM-dd";
        public const string UserPassportTokenKey = "UserPassportToken";
        public const string UserRefreshTokenKey = "UserRefreshToken";
        public const string SSOClientTokenIdentifierKey = "IdentifierId";
        public const string SuccessPropertyField = "IsSuccessStatusCode";
        public const string VerveMPinTypeCode = "VMP";
        public const string ECashPaymentMethodTypeCode = "QTA";
        public const string CurrencyCodeForNigeria = "566";
        public const string HangFireConnectionPlaceHolder = "Hangfire:RedisConnectionString";
        public const string ReferralRetryIntervalInMinutes = "Hangfire:ReferralRetryIntervalInMinutes";
        public const string CountryCodeForNigeria = "NG";
        public const string FailedOtpCode = "T1";
        public const string OtpResponseCode = "T0";
        public const string FailedToGenerateOtpCode = "TF";
        public const string ReferrerNotFoundCode = "REFERRER_NOT_FOUND";
        public const string TransferTransactionType = "TransferToAccount";
        public const string RechargeTransactionType = "Recharge";
        public const string PrepaidTransactionType = "Prepaid";
        public const string BillPaymentTransactionType = "BillPayment";
        public const string PostpaidTransactionType = "Postpaid";
        public const string RecurringBillingOTPCode = "T0";
        public const string RecurringBillingOTPValidationFailed = "T1";
        public const string RecurringBillingOTPSuccess = "10005";
        public const string RecurringBillingSuccessCode = "00";
        public const string RecurringBillingActiveStatus = "ACTIVE";
        public const string RecurringBillingCancelledStatus = "CANCEL";
        public const string RecurringBillingCompletedStatus = "COMPLETED";
        public const string RecurringBillingInactiveStatus = "INACTIVE";
        public const string ShowSwaggerDashboard = "ShowSwaggerDashboard";
        public const string WebPayTransactionNotCompleted = "900Z0";
        public const string ExceptionCommonWords = "unexpected character,unexpected end,object reference,exception occurred, sqlexception,ioexception,runtimeexception,index out of bound,index out of range,sql server";
        public const string DefaultExceptionFriendlyMessage = "Unable to process your request at the moment, please try again later.";
        public const string InActiveFingerPrintUpdate = "Device Id provided is not currently active for this user";

        public const string HeaderTerminalIdKey = "terminalId";
        public const string USSDApiKey = "api-key";

        public const string EcashDepositLimit = "[EcashDepositLimit]";
        public const string UserDepositLimit = "[UserDepositLimit]";

        public const string WesternUnionCountryElement = "PayerCountryCode";

        public const string CustomAuthorization = "CustomAuthorization";
        public const string HttpclientDefault = "default";

        public const string NewDevice = "New Device";
        public const string EnabledExistingDevice = "Exisiting Device  And Enabled";
        public const string DisabledExistingDevice = "Existing Device But Disabled";

        public const string HeaderDeleteTokenRedisKey = "::Delete-Token::";
        public const string HeaderDeleteTokenKey = "delete-token";
        public const string HeaderEmailKey = "email";
        public const string HeaderPhoneKey = "phone";
        public const string HeaderAnonymousIdentifierKey = "identifier";
        public const string RedisNamespace = "QT:Web";
        public const string QTWalletNamespace = "QT:Wallets";
        public const string QTUSSDPrefix = "QT:USSD:";
        public const string Ecash = "eCash";
        public const string EcashActiveStatus = "active";
        public const string WebPaySucessCode = "00";
        public const string WebPayUssdBanksKey = "QT:Web:WebPayUssdBanksKey";
        public const string LendingServiceSucessCode = "00";

        public const string TripleDESRedisKey = "QT:Web:qtService:CmsRedisTripleDesKey";
        public const string TripleDESKey = "TripleDES";
        public const string AccountType = "00";
        public const string UserId = "QuickTeller Ecash";
        public const string EcashIssuerNumber = "1";
        public const string EcashCVV2 = "000";
        public const string PayPhoneServices = "{http://payphone.services}" + "KMsgResponse";
        public const string Return = "return";
        public const string PaymeLinkKafkaTopic = "payme-link-order-record";
        public const string QuickTellerKafkaTopic = "quickteller-website-trace";
        public const string QuickTellerKafkaLogTopic = "quickteller-website-log";
        public const string CreateReferralTopic = "create-referral";

        public const string NameInquiryDateOfBirthFormat = "yy/MM/dd";
        public const string NameInquiryResponseBVNAccountType = "bvn";
        public const string KycDateOfBirthFormat = "yyyy-MM-dd";
        public const string BVNRequestPendingVerification = "entity_already_exists";
        public const string SafetokenSuccessfulCode = "00";
        public const string SafetokenInvalidOtpCode = "99";

        public const string QtServiceRedisNameSpacePrefix = "qtService";
        public const string QTWebpaysingleCallRedisTransactionReferrenceKey = "QT:Webpay_Direct:Transaction_Queue_key";
        public const string QTSvaSendAdviceRedisKey = "QT:SvaSendAdvice:Transaction_Queue_key";
        public const string QtCardCummulativeDetailsPrefix = "QT:CardCummulativeDetailsKey";


        public const string ChakaAuthenticationUrl = "/api/v1/security/investment-token";
        public const string GrantType = "client_credentials";
        public const string Scope = "profile";
        public const string QTChakaFallBackCode = "QT001";
        public const string QTChakaMerchantTokenNotFound = "QT404";
        public const string ChakaId = "chakaId";
        public const string MerchantTokenNotFound = "MerchantTokenNotFound";
        public const string ChakaIdNotAvailable = "not available";


        public const string DuplicateUserNameErrorCode = "60011";

        public const string VerveIdWebPayChannel = "FACE_ID";
        public const string SuccessText = "Successful";

        public const string SystemMasterKey = "QT:Webpay_Direct:Service_Master_Key";
        public const string QTFailedPINResponseCodes = "90055,90075,90X03,90X04,10400";
        public const string InterswitchSignatureKeyInHeader = "X-Interswitch-Signature";

        public const string PaycodeProviderCode = "paycode";
        public const string PaycodeRedemptionChannel = "web";

        public class QuicktellerAdviceResponseCode
        {
            public const string Successful = "90000";
            public const string AdvicePreviouslySent = "70022";
        }

        public class WebPayTransactionType
        {
            public const string BillPayment = "BILLPAYMENT";
            public const string PrepaidCardLoad = "PREPAIDCARDLOAD";
            public const string Recharge = "RECHARGE";
        }

        public class BankAccountType
        {
            public const string NotSure = "00";
            public const string Savings = "10";
            public const string Current = "20";
            public const string Credit = "30";
        }

        public class IDSConstants
        {
            public static byte[] EncryptionIV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            public static int EncryptionBlockSize = 128;
            public static string EncryptionKey = "fdgfhhhhg5678hjy6765j76";
        }
    }
}
