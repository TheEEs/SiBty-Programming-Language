# SiBty Programming Language Quick Guide



#### Giới thiệu

... Là một ngôn ngữ lập trình kịch bản. SiBty sở hữu một concept đơn giản nhưng linh hoạt, có thể được sử dụng cho mục đích giáo dục hoặc nhúng vào các ứng dụng lớn hơn.

Bạn có thể sử dụng SiBty nhằm gia tăng khả năng tùy biến ứng dụng cho người dùng. Tuy nhiên, sự đơn giản và thanh lịch trong cú pháp khiến SiBty hoàn toàn có khả năng trở thành một ngôn ngữ giảng dạy thay thế Pascal.





### 1.Main Concepts



Dưới đây là một vài concepts dùng để tạo nên SiBty. Các concept này được vay mượn chủ yếu từ hai ngôn ngữ là `Lua` và `Ruby`:

* Mọi thứ trong **SiBty** đều là các biểu thức, kể cả các hàm, các cấu trúc rẽ nhánh.
* Kiểu động. 
* Đơn giản hóa mọi thứ.



`SiBty` dung hòa được những điểm mạnh và điểm yếu của cả hai ngôn ngữ trên. Trong khi Lua gọn nhẹ nhưng quá nghèo nàn , Ruby có cú pháp thanh lịch nhưng nội dung quá đồ sộ. `SiBty` cố gắng để cân bằng giữa `sự linh hoạt của cú pháp`  và `vừa đủ thứ để học`. Các sections dưới đây sẽ cung cấp những ví dụ đi kèm giải thích để bạn tiếp cận với ngôn ngữ này.



### 2. Các kiểu chính

Có 6 kiểu dữ liệu cơ bản trong `SiBty`, bao gồm:
* Number - số nguyên
* Float - số dấu chấm động
* Boolean - Kiểu logic
* Nil - Không gì cả
* String - chuỗi ký tự
* Array - Mảng các phần tử
* Hash - ở phiên bản này, hash có chức năng tương tự như `struct` trong **C**
* Function - chương trình con



### 3. Các toán tử

Các toán tử trong `SiBty` được liệt kê trong bảng dưới đây, theo độ ưu tiên giảm dần:

| Toán tử                                  | Giải thích                  |
| ---------------------------------------- | --------------------------- |
| ()                                       | Gộp nhóm                    |
| <ID>()                                   | Gọi hàm                     |
| do ... end                               | khai báo hàm                |
| var <ID>                                 | khai báo biến               |
| print                                    | in ra màn hình              |
| if - while                               | cấu trúc rẽ nhánh, vòng lặp |
| <expression>[<expression>]               | member access               |
| + - <expression>                         | âm - dương                  |
| !                                        | Logic not                   |
| ~ <expression>                           | Bitwise not                 |
| <expression> \** <expression>            | số mũ                       |
| <expression> \* / % <expression>         | có tính nhân                |
| <expression> + -                         | có tính trừ                 |
| <expression> << >> <expression>          | Shift trái - Shift phải     |
| <expression> <= >= < > <expression>      | phép quan hệ                |
| <expression> \<> == <expression>         | so sánh bằng                |
| <expression> & \| ^                      | bitwise and-or-xor          |
| <expression> && and                      | toán tử logic               |
| <expression> [<expression>] = <expression> | member setting              |
| <ID> = <expression>                      | phép gán                    |

### 4. Comments

Bạn có thể comment out một đoạn code bằng cách đặt một ký tự `#` vào dòng đó.
Tất cả các ký tự từ dấu `#` tới ký tự *'\n'* đầu tiên được tìm thấy sẽ bị trình biên dịch bỏ qua.

```ruby
#đây là một bình luận
"nhưng đây thì không"
```





### 5. Line-terminators.

Một dòng lệnh trong `SiBty` được kết thúc bằng ký tự xuống dòng `\n` hoặc `;`. 

```javascript
var x = 1+1;print x
```

Tuy nhiên trong một vài trường hợp, ký tự xuống dòng sẽ bị bỏ qua. 

```javascript
print 1+
  1
```

Câu lệnh phía trên hoàn toàn hợp lý bởi khi scan tới token`+`. Trình biên dịch sẽ nhận ra rằng nó cần phải có một toán hạng nữa phía sau dấu `+`. Trình dịch sẽ lập tức bỏ qua ký tự xuống dòng này và match token `1` phía sau nó. Nếu không, trình dịch sẽ báo những lỗi cú pháp , ví dụ:



```lua
print 4 +
 
SiBty error (2:0) -> missing an expression after "+" token

^
```



### 6. Kết quả của phép toán.

Khác với các ngôn ngữ khác, kiểu trả về của phép toán trong `SiBty` sẽ được quyết định bởi toán hạng đứng trước. Chúng ta có thể lấy một ví dụ giữa **Ruby** và **SiBty** để thấy được sự khác biệt:

```ruby
#Ruby: int + float = float
4 + 0.5 #0.5
```

```ruby
#SiBty: int + float = int
4 + 0.5 #4
```



### 7. Khai báo biến.

Bạn sử dụng từ khóa `var` để khai báo một biến. Nếu bạn không gán một giá trị, biến vừa khai báo sẽ mang giá trị `nil`.

```javascript
var hex= 0x8;
var octal =   0o21;
var bin = 0b101010111000111;
```

Do mọi thứ trong `SiBty` được coi là các biểu thức, bạn có thể sử dụng khai báo biến để làm dữ liệu đầu vào cho các câu lệnh khác, ví dụ:

```javascript
print var c ="Hello world"
```



### 8. If-elif-else.

Cấu trúc `if` trong ngôn ngữ này cũng được xem là một biểu thức. Giá trị mặc định của nó trả về là `nil`. Tuy nhiên bạn có thể dùng câu lệnh `break` để thoát khỏi lệnh `if` đồng thời thay thế một giá trị trả về mới.

```ruby
kq= if a % 2 ==0
 break "a la so chan"
else
 break "a la so le"
end
```



### 9. while.

`while` là một vòng lặp cơ bản trong lập trình. Trong `SiBty` , khi vòng while kết thúc, nó sẽ trả về giá trị của biểu thức điều kiện. Do đó, trên lý thuyết thì trừ khi là một vòng lặp vô hạn ,giá trị của vòng while luôn luôn là `false`. Bạn có thể sử dụng lệnh `stop` để thoát khỏi vòng while và thay thế giá trị trả về mặc định.



Ngoài ra, đối với vòng `while` , bạn sử dụng `continue` để tiếp tục một iteration mới.

### 10. Where is my `for` loops ?

Một trong những concept của `SiBty`, đó là đơn giản hóa mọi thứ. `SiBty` loại bỏ vòng for. Tuy nhiên, đội ngũ phát triển chấp nhận khả năng sẽ có những lập trình viên đã có kinh nghiệm với C hay Java. Do đó bạn có thể giả lập vòng `for` bằng một hàm *built-in* cùng tên. Hàm này sẽ trả về `true` nếu vòng for chạy hết hoặc không có một iterator nào, `false` nếu vòng for bị ngắt giữa chừng.

Hàm `for` nhận 4 tham số. 3 tham số đầu là các giá trị *Number*, lần lượt là *giá trị khởi tạo*,*giá trị đích*, *bước nhảy*.

Tham số cuối cùng là một hàm **X**, hàm này có một tham số thể hiện cho giá trị biến đếm. Nếu hàm **X** này trả về giá trị `trusty`, vòng lặp tiếp tục, ngược lại vòng lặp bị ngắt, hàm for trả về giá trị `false` cho thấy rằng nó đã không thể chạy hết như mong đợi.



Dưới đây là một ví dụ kiểm tra biến a có phải là một số nguyên tố hay không.



```ruby
var a = 55
if for(2,a/ 2,1,do i
		if a%i==0 return false end
		return true
	end)
	print a, "la so nguyen to"
else
	print a," khong phai la so nguyen to"
end
```



### 11. Functions

Hàm trong `SiBty` được khai báo trong cặp từ khóa `do`...`end`. Giá trị trả về mặc định của hàm là `nil`. Bạn có thể dùng từ khóa `return <expression>` để trả về một giá trị khác cho hàm đó. Dưới đây minh họa một hàm tìm ước chung lớn nhất

```ruby
var ucln= do a,b
 while a<>b
  if a > b a=a-b else b=b-a end
 next
 return a
end

print ucln(8,9)
```

### 12. Gọi hàm

Bạn sử dụng cặp ngoặc **( )**, bao quanh một danh sách các tham số truyền vào hàm. Vì lý do cú pháp, toán tử gọi hàm chỉ có thể sử dụng ngay sau một định danh hoặc một khai báo hàm, ví dụ



```ruby
ucln(a,b)
```

hoặc

```ruby
print do a,b
  while a<>b
  if a > b a=a-b else b=b-a end
 next
 return a
end(4,20)
```



### 13. Array

Array là một tập hợp các phần tử. `SiBty` hỗ trợ array, để khai báo một array, bạn sử dụng cặp ngoặc vuông **[ ]**. các phần tử trong mảng cách nhau bởi dấu `,`. Để truy xuất đến một phần tử trong array, bạn sử dụng cú pháp `<expression>[<expression>]`. Để thiết đặt một giá trị mới cho phần tử trong Array, bạn sử dụng cú pháp `<expression>[<expression>] = <expression>`.

Dưới đây là ví dụ về cách sắp xếp một mảng sử dụng thuật toán Interchange sort.

```ruby
var array=[1,6,5,2,7,2]
for(0,5,1,do i
  for(i,5,1,do j
   if array[j] < array[j]
     var temp = array[j]
     array[j]= array[i]
     array[i] = temp
   end
   return true
  end)
  return true 
end)
print array
```





### 14. Hash. 

Với phiên bản hiện tại , hash trong `SiBty` có chức năng tương đương như struct trong C. Cú pháp khai báo hash của `SiBty` được vay mượn từ Ruby. Ví dụ:

```ruby
var hash = {a => "this is a hash"}
```

Bạn truy cập tới các phần tử trong hash bằng toán tử **[<expression>]**. Thiết đặt các phần tử cho hash bằng toán tử **<expression>[<expression>)=<expression>**



### 15. Gọi hàm thành viên.

SiBty coi các hash là các object sơ khai. Bạn có thể gọi hàm trong hash bằng cú pháp:

```ruby
{greeting=> "helloworld", function=> do this
  print this["greeting"]
end}.function()
```

Hãy chú ý tới member `function` trong hash trên. Đây được coi là một hàm thành viên. Tham số đầu tiên trong hàm này là `this`(có thể thay tên khác nếu muốn). Khi bạn gọi một hàm thành viên từ một hash, trình biên dịch sẽ tự động truyền hash đó vào tham số đầu tiên. Phương pháp này được vay mượn từ Python. Do đó, bạn cũng có thể tách riêng một hàm thành viên sau đó truyền hash vào tham số đầu tiên của nó. Ví dụ:

```ruby
var hash ={greeting=> "helloworld", function=> do this
  print this["greeting"]
end}
var fn= hash["function"]
fn(hash)
```



Vì lý do cú pháp, ở phiên bản này, bạn chỉ có thể sử dụng toán tử gọi hàm thành viên ngay sau một định danh hoặc ngay sau một hash. Đây là một sự bất tiện, đội ngũ phát triển sẽ khắc phục trong những ấn bản sắp tới.

### 16. Viết extensions cho SiBty
Những tính năng built-in trong SiBty rất đơn giản. Trong nhiều trường hợp lập trình viên sẽ muốn mở rộng ngôn ngữ này để phục vụ thêm các mục đích của mình.
SiBty cho phép các nhà phát triển tạo ra extensions cho nó. Có hai phương pháp giúp bạn tạo ra các extension.
##### 16.1 Simple case
Nếu bạn chỉ muốn tạo ra vài phương thức đơn lẻ, đây sẽ là lựa chọn của bạn.
SiBty cung cấp một lớp `ExternalFunction` cho phép bạn tạo ra các phương thức bên ngoài bằng C#, VB.Net, F#, ..etc.. và import chúng vào máy ảo SiBtyVM. Các ExternalFuction này sau đó có thể được truy cập thông qua các định danh như thông thường.
```C#
void main(){
	SiBtyVirtualMachine  vm = new SiBtyVirtualMachine();
	ExternalFunction.__function__  greeting = (ExternalFunction self) => {
		Planguage.String name = self.load_var("name").type_cast(Types.String) as Planguage.String;
		System.Console.WriteLine("hello {0}",name.value_);
		self.set_return_value(new Planguage.Boolean(true));
	}
	//new ExternalFunction(
		//space, //space to which this function belongs, maybe a function or the root space of program
		//function, // the delegate of the C# function body 
		//parameter_list // pamameters of this external function will be defined here, in this case "name"
		//);
	vm.set_variable("hello",new ExternalFunction(vm.root_space, greeting, "name");
	vm.load_from_input_stream();//or vm.load_from_file();
}
```

Sau khi định nghĩa phương thức mở rộng, chúng ta có thể truy cập nó trong SiBty như dưới đây:
```ruby
hello("tran ba dat")
#output : hello tran ba dat
```
##### 16.2 Advanced case
Trong trường hợp bạn muốn các extensions của mình được module hóa, vd: các extension chuyên xử lý việc đọc, ghi file. SiBty cung cấp lớp `BaseUtility` giúp nhà phát triển gộp các external methods vào các module để dễ dàng quản lý. 
Ví dụ dưới đây sẽ tạo ra một Extension module chuyên về các hàm toán học.
```C#
public class MathUtils : BaseUtility{
	public MathUtils(){
		this.name_space = "math";
		// this name_space will be prefixed on every external function in this module. We can leave it empty.
	}
	
	//we will define external functions here
	//all external methods must be static, void, and accept only one parameter of type ExternalFunction
	
	/*
	External attribute has two field: function_name and parameters 
	function_name will be the variable name we use to access the function in SiBty programs
	parameters is the list of parameters's name as we defined in the simple case above
	*/
	[External(parammeters = new string[] { "number" })]
        public static void square(ExternalFunction function){
		Planguage.Float input = function.load_var("number").type_cast(Types.Float) as Planguage.Float;
		function.set_return_value(new Planguage.Float(input._value * input._value));
	}
}
```

Sau khi đã định nghĩa extension module như trên, chúng ta tiến hành load nó vào SiBty VM:
```C#

void Main(){
	var vm = new SiBtyVirtualMachine();
	vm.load_external_methods(new MathUtils());
	vm.load_from_input_stream();
}

```

Sau đó chúng ta có thể truy cập vào các extension methods trong module trên như sau:
```ruby
print math_square(56.2)
# 'math_square' instead of 'square' because we defined "math" as namespace of this module
```

### 17. Object-Oriented-Programing (or something similar)
Ngay từ đầu SiBty không được thiết kế để trở thành một ngôn ngữ hướng đối tượng, tuy nhiên các chương trình trong SiBty vẫn có thể sử dụng pattern này nếu muốn.

SiBty chưa có cú pháp chính thức để tạo ra một object. Cách duy nhất để tạo ra các object cho đến hiện tại, đó là sử dụng extension method `obj_create`.

Hàm `obj_create` nhận vào một hàm `X` với ít nhất một tham số, một đối tượng mới sẽ được truyền vào tham số đầu tiên. Giá trị trả về của `obj_create` chính là giá trị trả về của hàm `X`. Do đó nếu muốn `obj_create` trả về một đối tượng mới, trong hàm `X` bạn cần return tham số đầu tiên. Chương trình dưới đây sẽ tiến hành tạo ra một đối tượng:
```ruby
module_require("sibty/utils/utils.plang")
var new_person = do name,age,gender
	return obj_create(do person
		person["name"] = name
		person["age"] = age
		person["gender"] = gender
		person["greet"] = do self
			print "Hello , my name is ", self["name"], str_nl()
		end
		person["sex"] = do self
			return if self["gender"]
				break "male"
			else
				break "female"
			end
		end
		return person	
	end)
end
#true is male
#false is female
var dat = new_person("Dat", 20, true)
dat.greet()
print "I'm a ", dat.sex() , str_nl()
```

### 18. Operator-Overriding
Các toán tử trong SiBty được biên dịch thành các member đặc biệt.
Ví dụ : để ghi đè toán tử `+`, bạn cần phải thiết đặt member `"add"` của một đối tượng
```ruby
var object = obj_create(do object
	object["a"] = 0
	object["add"] = do self,value
		return self["a"] + value
	end
	return object
end)
print object["a"], str_nl()
object["a"] = 6
console_write_line(object + 6)
# output : 12
```

Bảng dưới đây liệt kê các toán tử và tên tương ứng của chúng:

| Operator | Corresponding name      |
| -------- | ----------------------- |
| +        |      positive           |
| -        |      negative           |
| []       |      member_access      |
| !        |      bool_not           |
| ~        |      bitwise_not        |
| **       |      exponent           |
| *        |      mul                |
| /        | div                     |
| %        |      remainder          |
| +        |      add                |
| -        |      sub                |
| <<       |      lshift             |
| >>       |      rshift             |
| <        |      smaller            |
| <=       |      smaller_or_equal   |
| >        |      bigger             |
| >=       |      bigger_or_equal    |
| ==       |      equal              |
| <>       |      different          |
| &        |      bitwise_and        |
| |        |      bitwise_or         |
| ^        |      bitwise_xor        |
| &&       |      logic_and          |
| ||       |      logic_or           |
| []=     |      member_setting      |

> **Important!!**: 
> Hãy chú ý khi ghi đè hai toán tử `[]=` và `[]` vì chúng có thể khiến đối tượng không hoạt động được nữa
