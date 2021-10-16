# CurrencyConverter
ISD Lab#1 Project: Introduction to ASP.NET Core with MVC Pattern 

## Lab requirements:
<p>
Sinh viên hãy thực hiện lại bài hướng dẫn trên để hiểu cách hoạt động hệ thống, hiểu cách
áp dụng mô hình MVC trong ASP.NET.<br/>
Yêu cầu: Sinh viên xây dựng một trang web đơn giản để tính toán việc chuyển đổi tiền tệ
từ $ sang VNĐ.<br/>
Hai tham số cần cung cấp là số tiền cần đổi, tỉ giá $, kết quả trả về tiền VNĐ.
<p>

## Result description

### Controller: ```ConverterController.cs```
Định nghĩa hàm Index trả về view Converter/Index.
```
public IActionResult Index()
{
    return View("Index");
}

public IActionResult Convert(float amount, float exchangeRate)
{
    Models.Converter converter = new Models.Converter(amount, exchangeRate);
    converter.convert();
    return View("Index", converter);
}

public object AjaxConvert(float amount, float exchangeRate)
{
    Models.Converter converter = new Models.Converter(amount, exchangeRate);
    converter.convert();
    string result = "Result: " + converter.result.ToString("0,000.0000") + " VND";
    return result;
}
```
Hàm ```AjaxConvert``` được sử dụng cho phương thức AJAX từ converter.js.

### Model: ```Converter.cs```
Định nghĩa các thuộc tính và phương thức của model chuyển đổi tiền tệ.
| Tên          | Loại                 | Kiểu dữ liệu/trả về | Mô tả                                                              |
|--------------|----------------------|---------------------|--------------------------------------------------------------------|
| ```amount```| thuộc tính           | float               | Giá trị tiền (USD) cần quy đổi                                     |
| ```exchangeRate```| thuộc tính           | float               | Tỉ giá quy đổi                                                     |
| ```result``` | thuộc tính           | float               | Kết quả quy đổi                                                    |
| ```Converter```| phương thức khởi tạo |                     | Khởi tạo amount và exchangeRate                                    |
| ```convert```| phương thức          | void                | Quy đổi dựa trên amount và exchangeRate và lưu kết quả vào result. |

### View: ```Converter/Index.cshtml```
Các thành phần chính trong view:
| Loại   | ID(#)/Class(.) | Mô tả                          |
|--------|----------------|--------------------------------|
|```input```|```#amount```| Nhập giá trị cần quy đổi       |
|```input```|```#exchange-rate```| Nhập tỷ giá quy đổi            |
|```button```|```#convert```| Nhấp để thực hiện quy đổi tiền |
|```label```|```.result```| Hiển thị kết quả quy đổi       |

View có sử dụng stylesheet ```converter.css``` và script ```converter.js``` (jQuery).

Trang chuyển đổi tiền tệ: /converter
