using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Planiture_Website.Models
{
    public class UploadSignDocumentClass
    {
        //Withdrawal form data
        
        public String wFullName { get; set; }
        public DateTime wDateFilled { get; set; }
        public int wAmount { get; set; }
        public String wSignature { get; set; }
        public DateTime wDateSigned { get; set; }


        //The document uploaded from computer through browser

        //public File uploadedDocument


        //Deposit form data

        public String dFullName { get; set; }
        public DateTime dDateFilled { get; set; }
        public int dAmount { get; set; }
        public String dSignature { get; set; }
        public DateTime dDateSigned { get; set; }

        //Payment authorization form data



    }
}
