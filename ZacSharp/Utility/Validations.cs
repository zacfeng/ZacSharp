using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZacSharp.Utility
{
    public class Validations
    {
        public const string FullNameRegex = @"^([a-zA-Z]+([\-]?[a-zA-Z]+){0,2})( [a-zA-Z]+([\-]?[a-zA-Z]+){0,2})? ([a-zA-Z]+([\-]?[a-zA-Z]+){0,2})$"; // full name validation "Firstname Lastname" or "Lastname Firstname" or "Firstname Middlename Lastname"
        public const string NameRegex = @"^[a-zA-Z]+$";
        public const string PasswordRuleRegex = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{8,25}$"; // password must be at least 8 characters long, 1 Uppercase letter, 1 Numeric Character
        public const string DigitRuleRegex = @"^[0-9]$";
        public const string StateRegex = @"^(A[LKSZRAEP]|C[AOT]|D[EC]|F[LM]|G[ANU]|HI|I[ADLN]|K[SY]|LA|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[ARW]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$";
        public const string ZipRegex = @"^\d{5}(?:[-\s]\d{4})?$";
        public const string USPhoneRuleRegex = @"^(1-?)?(\([2-9]\d{2}\)|[2-9]\d{2})-?[2-9]\d{2}-?\d{4}$"; // USA phone validation rule @"^[0-9]{3}\-[0-9]{3}\-[0-9]{4}$"
        public const string RoutingNumberRuleRegex = @"^[0-9]{9}$"; //
        public const string EmailRuleRegex = @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"; //@"^([0-9a-zA-Z].*?@([0-9a-zA-Z].*\.\w{2,4}))$"; // email validation rule
        public const string NumericRuleRegex = @"^(\d)*(,\d{3})*([.]\d*)?$";
        public const string DateRegex = @"^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$";
    }
}
