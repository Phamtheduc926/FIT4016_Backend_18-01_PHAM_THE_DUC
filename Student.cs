using System;

// Lớp Student chứa thông tin và điểm của 1 sinh viên
public class Student
{
    // Khai báo các thuộc tính là non-nullable reference type (string), 
    // vì chúng được đảm bảo giá trị trong Constructor
    public string StudentId { get; set; }
    public string Name { get; set; }
    public double Score { get; set; }
    
    // Constructor
    public Student(string id, string name, double score)
    {
        // --- VALIDATION SẼ NÉM LỖI TRƯỚC KHI GÁN NULL ---
        
        // Validation: StudentId không được rỗng
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Lỗi: ID sinh viên không được để trống.");
        }
        
        // Validation: Name không được rỗng
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Lỗi: Tên sinh viên không được để trống.");
        }
        
        // Validation: Score phải từ 0 đến 10
        if (score < 0 || score > 10)
        {
            throw new ArgumentException($"Lỗi: Điểm ({score}) phải nằm trong khoảng từ 0 đến 10.");
        }

        // Khởi tạo thuộc tính nếu validation thành công
        this.StudentId = id.Trim().ToUpper();
        this.Name = name.Trim();
        this.Score = score;
    }
    
    // Phương thức in thông tin
    public void Display()
    {
        Console.WriteLine($"ID: {StudentId} | Tên: {Name} | Điểm: {Score:F2}");
    }
}