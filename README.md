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
