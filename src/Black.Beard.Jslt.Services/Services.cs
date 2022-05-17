using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Oldtonsoft.Json.Linq;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Jslt.Services
{


    public static partial class Services
    {


        [JsltExtensionMethod("phoneisvalid")]
        [JsltExtensionMethodParameter("phoneNumber", "phone number to evaluate")]
        [JsltExtensionMethodParameter("defaultRegion", "default prefix region")]
        public static JToken ExecutePhoneIsValid(RuntimeContext ctx, string phoneNumber, string defaultRegion)
        {

            try
            {

                //Création de l'intance PhoneNumberUtil
                var util = PhoneNumberUtil.GetInstance();
                PhoneNumber number = null;


                //Si le numéro contient l'indicatif + ou le 00
                if (phoneNumber.StartsWith("+") || phoneNumber.StartsWith("00"))
                {
                    
                    if (phoneNumber.StartsWith("00"))
                        phoneNumber = "+" + phoneNumber.Remove(0, 2);

                    number = util.Parse(phoneNumber, "");
                    
                    // Récupération de la région au numéro avec l'indication +
                    string regionCode = util.GetRegionCodeForNumber(number);
                    
                    // Validation du numéro qui correspond à la région trouvées
                    return new JValue( util.IsValidNumberForRegion(number, regionCode));

                }
                else
                {
                    number = util.Parse(phoneNumber, defaultRegion);
                    // Validation du numéro sans indication mais avec le region code
                    return util.IsValidNumber(number);
                }

            
            }
            catch (NumberParseException)
            {
                //LOG
                return new JValue(false);
            }

        }

    }

}
