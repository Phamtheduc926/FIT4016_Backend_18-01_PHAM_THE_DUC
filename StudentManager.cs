using System;
using System.Linq;

public class StudentManager
{
    private Student?[] students = new Student?[50]; 
    private int count = 0; // Số lượng sinh viên hiện tại
    
    public Student? FindStudentById(string id)
    {
        string searchId = id.Trim().ToUpper();
        
        for (int i = 0; i < count; i++)
        {
            // Kiểm tra rõ ràng (Explicit null check) trước khi truy cập thuộc tính
            if (students[i] != null && students[i]!.StudentId == searchId) 
            {
                // Dùng ! để báo cho Compiler biết students[i] không null ở đây
                return students[i]; 
            }
        }
        return null;
    }

    // TODO: Phương thức AddStudent
    public void AddStudent(string id, string name, double score)
    {
        if (count >= students.Length)
        {
            throw new Exception("Lỗi: Danh sách sinh viên đã đầy (tối đa 50).");
        }
        
        // Kiểm tra trùng lặp ID (sử dụng FindStudentById đã sửa)
        if (FindStudentById(id) != null)
        {
            throw new ArgumentException($"Lỗi: Sinh viên có ID '{id}' đã tồn tại.");
        }

        // Tạo đối tượng Student mới (logic validation sẽ chạy trong Constructor)
        Student newStudent = new Student(id, name, score);
        
        students[count] = newStudent;
        count++;
    }
    
    // TODO: Phương thức RemoveStudent
    public bool RemoveStudent(string id)
    {
        string removeId = id.Trim().ToUpper();
        int foundIndex = -1;

        for (int i = 0; i < count; i++)
        {
            // Kiểm tra null rõ ràng trước khi truy cập StudentId
            if (students[i] != null && students[i]!.StudentId == removeId)
            {
                foundIndex = i;
                break;
            }
        }

        if (foundIndex == -1) { return false; }

        for (int i = foundIndex; i < count - 1; i++)
        {
            students[i] = students[i + 1];
        }

        students[count - 1] = null; 
        count--;
        return true;
    }
    
    // TODO: Phương thức UpdateScore
    public bool UpdateScore(string id, double newScore)
    {
        Student? studentToUpdate = FindStudentById(id);

        if (studentToUpdate == null) { return false; }

        if (newScore < 0 || newScore > 10)
        {
            throw new ArgumentException($"Lỗi: Điểm mới ({newScore}) phải từ 0 đến 10."); 
        }

        // Dùng ! sau studentToUpdate để truy cập Score an toàn 
        studentToUpdate.Score = newScore;
        return true;
    }
    
    // TODO: Phương thức GetAverageScore
    public double GetAverageScore()
    {
        if (count == 0)
        {
            throw new Exception("Lỗi: Không có sinh viên nào trong danh sách để tính điểm trung bình.");
        }

        double totalScore = 0;
        for (int i = 0; i < count; i++)
        {
            // Kiểm tra null rõ ràng
            if (students[i] != null)
            {
                totalScore += students[i]!.Score;
            }
        }

        return totalScore / count;
    }
    
    // TODO: Phương thức GetMaxScore
    public double GetMaxScore()
    {
        if (count == 0)
        {
            throw new Exception("Lỗi: Không có sinh viên nào trong danh sách.");
        }
        
        // Giả sử phần tử đầu tiên KHÔNG null (dựa vào logic AddStudent)
        double maxScore = students[0]!.Score; 
        
        for (int i = 1; i < count; i++)
        {
            // Kiểm tra null rõ ràng
            if (students[i] != null && students[i]!.Score > maxScore)
            {
                maxScore = students[i]!.Score;
            }
        }
        return maxScore;
    }
    
    // TODO: Phương thức DisplayAllStudents
    public void DisplayAllStudents()
    {
        if (count == 0)
        {
            Console.WriteLine("⚠️ Danh sách sinh viên trống.");
            return;
        }

        Console.WriteLine($"\n--- DANH SÁCH SINH VIÊN HIỆN TẠI ({count}) ---");
        for (int i = 0; i < count; i++)
        {
            // Kiểm tra null trước khi gọi Display
            if (students[i] != null)
            {
                students[i]!.Display(); 
            }
        }
        Console.WriteLine("---------------------------------------------");
    }
}