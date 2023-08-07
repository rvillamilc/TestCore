using ApiWebTest.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        [HttpPost]
        public ActionResult OperacionMat(Operaciones arg)
        {
            switch (arg.operacion)
            {
                case 1:
                    return Ok(new { message = " Resultado Suma: " + (arg.n1 + arg.n2) });
                //  return  " Resultado Suma: " + (arg.n1 + arg.n2);
                case 2:
                    return Ok(new { message = " Resultado resta: " + (arg.n1 - arg.n2) });
                case 3:
                    return Ok(new { message = " Resultado multiplicación: " + (arg.n1 * arg.n2) });
                case 4:
                    if (arg.n2 <= 0) { return Ok(new { message = "No se puede dividir por 0" }); }

                    if (arg.n1 > arg.n2) { return Ok(new { message = "El divisor es mayor que el dividendo" }); }


                    return Ok(new { message = " Resultado división: " + (arg.n1 / arg.n2) });

                default:
                    return Ok(new { message = "Introducir un operador válido (Suma:1, Resta:2, Multiplicacion:3, Divisón:4)" });
            }
        }

    }
}
