using System;
using System.Text;

 namespace PISlaba1.Models
{
    public class Lab1Data
    {
        public string SerialNumber {get;set;}
        public string Brand {get;set;}
        public string Model {get;set;}
        public int Year {get;set;}
        public string Type {get;set;}
        public Guid Id { get; set; } = Guid.Empty;
        public BaseModelValidationResult Validate()
        {
            var validationResult = new BaseModelValidationResult();
            
            if (string.IsNullOrWhiteSpace(SerialNumber)) validationResult.Append ($"SerialNumber cannot be empty");
            if (string.IsNullOrWhiteSpace(Brand)) validationResult.Append ($"Brand cannot be empty");
            if (!(1900<Year && Year<2020)) validationResult.Append ($"Year {Year} is out of range (1900..2020)");
            if (string.IsNullOrWhiteSpace(Type)) validationResult.Append ($"Type cannot be empty");  

            return validationResult;
 
        }
         public override string ToString()
         {
             //return $"{Brand} {Model} from {Year}-{Type}";
              return $"{Brand} {Model} from {SerialNumber}-{Year}-{Type}";
         }               
    }
   
                
}
    
