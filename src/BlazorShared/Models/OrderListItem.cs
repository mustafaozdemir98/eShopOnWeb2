using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorInputFile;
using System.ComponentModel.DataAnnotations;
using System.IO;


namespace BlazorShared.Models;
public class OrderListItem
{
    public int Id { get; set; }

    /*
    public int OrderlistTypeId { get; set; }
    public string OrderlistType { get; set; } = "NotSet";

    public int OrderlistBrandId { get; set; }
    public string OrderlistBrand { get; set; } = "NotSet";
    */
    public DateTimeOffset OrderDate { get; set; }


    // kullanıcı adı
    //[Required(ErrorMessage = "The Name field is required")]
    public string BuyerId { get; set; }

    //[Required(ErrorMessage = "The Description field is required")]
    /*
    public string Description { get; set; }
    */

    // decimal(18,2)
    /*
    [RegularExpression(@"^\d+(\.\d{0,2})*$", ErrorMessage = "The field Price must be a positive number with maximum two decimals.")]
    [Range(0.01, 1000)]
    [DataType(DataType.Currency)] 
    public decimal Total { get; set; }
    */

    //public string OrderStatus { get; set; } = "pending";



    public static async Task<string> DataToBase64(IFileListEntry fileItem)
    {
        using (var reader = new StreamReader(fileItem.Data))
        {
            using (var memStream = new MemoryStream())
            {
                await reader.BaseStream.CopyToAsync(memStream);
                var fileData = memStream.ToArray();
                var encodedBase64 = Convert.ToBase64String(fileData);

                return encodedBase64;
            }
        }
    }


}
