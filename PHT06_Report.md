# BÁO CÁO DỰ ÁN TỔNG HỢP (PHT C# [06])

## DỰ ÁN: HỆ THỐNG QUẢN LÝ SINH VIÊN

### Sinh viên: [Tên của bạn]
### Khóa học: Lập trình C# Backend Cơ bản

---

## MỤC LỤC

1.  Mục tiêu Dự án
2.  Kiến trúc và Logic
3.  Giải pháp Xử lý Lỗi (Validation & Exception Handling)
4.  Chứng thực Chức năng (Screenshots)
5.  Trả lời Câu hỏi Phản biện

---

## 1. MỤC TIÊU DỰ ÁN

Dự án này nhằm tổng hợp các kiến thức về Lập trình Hướng đối tượng (OOP) và Xử lý lỗi trong C# để xây dựng một hệ thống quản lý cơ bản cho danh sách sinh viên.

**Các chức năng đã hoàn thành:**
* Quản lý danh sách sinh viên (sử dụng mảng cố định `Student[]`).
* Thêm, Xóa, Cập nhật thông tin sinh viên.
* Tính toán thống kê: Điểm trung bình, Điểm cao nhất.
* Xử lý lỗi nhập liệu và lỗi nghiệp vụ (Validation) bằng `try-catch` và `throw`.

## 2. KIẾN TRÚC VÀ LOGIC

Dự án được chia thành 3 lớp chính theo nguyên tắc OOP:

### 2.1. Lớp `Student.cs` (Đối tượng)

* **Vai trò:** Đại diện cho một đối tượng sinh viên duy nhất.
* **Logic chính:**
    * Sử dụng **Constructor** để đảm bảo dữ liệu **hợp lệ** ngay khi đối tượng được tạo.
    * Thực hiện validation cơ bản cho `StudentId`, `Name` (không rỗng) và `Score` (từ 0-10). Nếu validation thất bại, ném `ArgumentException`.

### 2.2. Lớp `StudentManager.cs` (Quản lý nghiệp vụ)

* **Vai trò:** Chịu trách nhiệm quản lý tập hợp các đối tượng `Student`.
* **Logic chính:**
    * Sử dụng mảng `Student?[]` và biến `count` để quản lý danh sách.
    * Triển khai các phương thức nghiệp vụ: `AddStudent` (kiểm tra trùng ID, kiểm tra đầy mảng), `RemoveStudent`, `UpdateScore`, `GetAverageScore`, `GetMaxScore`.

### 2.3. Lớp `Program.cs` (Giao diện người dùng & Xử lý lỗi)

* **Vai trò:** Cung cấp giao diện Menu và là nơi tập trung xử lý lỗi tương tác với người dùng.
* **Logic chính:**
    * Sử dụng vòng lặp `while(running)` và khối `switch` để điều hướng Menu.
    * Sử dụng `try-catch` bao bọc việc nhận input và gọi các hàm nghiệp vụ, đảm bảo chương trình không bị crash khi người dùng nhập sai định dạng hoặc nhập dữ liệu vi phạm quy tắc validation.

## 3. GIẢI PHÁP XỬ LÝ LỖI (VALIDATION & EXCEPTION HANDLING)

| Loại Lỗi | Xử lý | Vị trí |
| :--- | :--- | :--- |
| **Validation** (Điểm > 10, ID rỗng) | Dùng `throw new ArgumentException(...)` | Constructor `Student` và `StudentManager.AddStudent` |
| **Lỗi Định dạng** (Nhập chữ thay vì số) | Dùng `catch (FormatException)` | `Program.cs` (khi `int.Parse` hoặc `Convert.ToDouble`) |
| **Lỗi Logic** (Danh sách đầy, Chia cho 0) | Dùng `throw new Exception(...)` | `StudentManager.AddStudent` và `StudentManager.GetAverageScore` |

## 4. CHỨNG THỰC CHỨC NĂNG (SCREENSHOTS)

*(Vui lòng thay thế các dòng chữ in hoa dưới đây bằng các ảnh chụp màn hình thực tế)*

### 4.1. Menu Chính & Danh sách Sinh viên

[CHÈN SCREENSHOT MENU CHÍNH VÀ DANH SÁCH MẪU Ở ĐÂY]

### 4.2. Thêm Sinh viên thành công & Cập nhật Điểm

[CHÈN SCREENSHOT KHI THÊM SINH VIÊN MỚI VÀ CẬP NHẬT ĐIỂM THÀNH CÔNG]

### 4.3. Xử lý Lỗi Validation (Điểm > 10) và Lỗi Định dạng (Nhập chữ)

[CHÈN SCREENSHOT KHI NHẬP ĐIỂM LÀ 15 VÀ KHI NHẬP CHỮ VÀO MỤC ĐIỂM]

### 4.4. Thống kê (TB/Max) và Xóa Sinh viên

[CHÈN SCREENSHOT KHI CHẠY CHỨC NĂNG TÍNH ĐIỂM TRUNG BÌNH, ĐIỂM CAO NHẤT VÀ XÓA SINH VIÊN]

## 5. TRẢ LỜI CÂU HỎI PHẢN BIỆN

### 1. Nếu người dùng nhập dữ liệu sai (ví dụ: điểm là 15), chương trình nên xử lý như thế nào?

* **Xử lý:** Chương trình sử dụng phương pháp **Validation (Kiểm tra nghiệp vụ)**.
* **Chi tiết:** Trong Constructor của lớp `Student` và phương thức `UpdateScore`, nếu điểm nhập vào không nằm trong khoảng 0-10, chương trình sẽ **ném ra (`throw`) một `ArgumentException`** với thông báo lỗi cụ thể. Khối `try-catch` trong `Program.cs` sẽ bắt lỗi này và in ra thông báo thân thiện cho người dùng, sau đó cho phép người dùng tiếp tục thao tác mà không bị dừng chương trình.

### 2. Có thể dùng `List<T>` thay vì array không? Ưu điểm gì?

* **Trả lời:** **Có thể và nên dùng `List<Student>`**.
* **Ưu điểm:**
    * **Kích thước Động:** `List<T>` tự động co giãn kích thước, loại bỏ giới hạn tối đa 50 sinh viên của mảng cố định.
    * **Thao tác Dễ dàng:** Thay vì phải code vòng lặp thủ công để dịch chuyển phần tử khi xóa (`RemoveStudent`), `List<T>` cung cấp sẵn phương thức `list.Remove(...)` giúp code sạch sẽ và hiệu quả hơn.

### 3. Nếu muốn lưu dữ liệu xuống file sau khi chương trình thoát, làm sao?

* **Giải pháp:** Cần sử dụng kỹ thuật **Serialization** (chuyển đối tượng thành chuỗi) và **File I/O** (đọc/ghi file).
* **Chi tiết:**
    1.  **Serialization:** Sử dụng thư viện `System.Text.Json` hoặc `Newtonsoft.Json` để chuyển đổi danh sách sinh viên (`Student[]` hoặc `List<Student>`) thành chuỗi định dạng JSON.
    2.  **Ghi file:** Dùng `System.IO.File.WriteAllText("students.json", jsonString)` để lưu dữ liệu này xuống file.
    3.  **Tải lại:** Khi chương trình khởi động, đọc file JSON và thực hiện **Deserialization** để chuyển chuỗi JSON thành các đối tượng `Student` và nạp lại vào `StudentManager`.