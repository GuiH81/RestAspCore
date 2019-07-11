using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestAspCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("{firstNumber}/{secoundNumber}/{type}")]
        public IActionResult Sum(string firstNumber, string secoundNumber, int type)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                var _operator = "";
                decimal sum = 0;
                switch (type)
                {
                    case 1:
                        _operator = "Sum = ";
                        sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secoundNumber);
                        _operator = _operator + sum.ToString();
                        break;
                    case 2:
                        _operator = "Subtraction = ";
                        sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secoundNumber);
                        _operator = _operator + sum.ToString();
                        break;
                    case 3:
                        _operator = "Multiplication = ";
                        sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secoundNumber);
                        _operator = _operator + sum.ToString();
                        break;
                    case 4:
                        _operator = "Division = ";
                        sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secoundNumber);
                        _operator = _operator + sum.ToString();
                        break;
                    default:
                        return BadRequest("Invalid Input");                        
                }

                //sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secoundNumber);
                return Ok(_operator.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secoundNumber}")]
        public IActionResult Subtraction(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secoundNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;

            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }

        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
