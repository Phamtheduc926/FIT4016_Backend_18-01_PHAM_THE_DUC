using System;

namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            bool running = true;

            while (running)
            {
                
                // TODO: Thêm try-catch để xử lý lỗi nhập liệu (Format, Overflow)
                try
                {
                    //Dùng ! để khẳng định Console.ReadLine() không null
                    string choiceInput = Console.ReadLine()!; 
                    int choice = int.Parse(choiceInput); 
                    
                    switch (choice)
                    {
                        case 1: HandleAddStudent(manager); break;
                        case 2: HandleRemoveStudent(manager); break;
                        case 3: HandleUpdateScore(manager); break;
                        case 4: manager.DisplayAllStudents(); break;
                        case 5: 
                            double avg = manager.GetAverageScore();
                            Console.WriteLine($"\n⭐ Điểm trung bình của tất cả sinh viên là: {avg:F2}");
                            break;
                        case 6: 
                            double max = manager.GetMaxScore();
                            Console.WriteLine($"\n🏆 Điểm cao nhất trong danh sách là: {max:F2}");
                            break;
                        case 7: HandleFindStudent(manager); break;
                        case 0: running = false; Console.WriteLine("Cảm ơn bạn đã sử dụng hệ thống! Tạm biệt. (^_^)/"); break;
                        default: Console.WriteLine("❌ Lựa chọn không hợp lệ. Vui lòng chọn lại (0-7)."); break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("❌ Lỗi: Vui lòng nhập đúng định dạng số cho lựa chọn menu.");
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"\n🛑 Đã xảy ra lỗi: {ex.Message}");
                    Console.WriteLine("Vui lòng thử lại thao tác.");
                }
            }
        }

        // --- HÀM HỖ TRỢ XỬ LÝ NHIỆM VỤ ---
        
        static void HandleAddStudent(StudentManager manager)
        {
            Console.Write("Nhập ID sinh viên: ");
            string id = Console.ReadLine()!; // Dùng !
            Console.Write("Nhập Tên sinh viên: ");
            string name = Console.ReadLine()!; // Dùng !
            Console.Write("Nhập Điểm (0-10): ");
            string scoreInput = Console.ReadLine()!; // Dùng !
            
            try
            {
                double score = Convert.ToDouble(scoreInput);
                manager.AddStudent(id, name, score);
                Console.WriteLine($"✅ Thêm sinh viên '{name}' thành công!");
            }
            catch (Exception ex) { Console.WriteLine($"\n🛑 Lỗi: {ex.Message}"); }
        }
        
        static void HandleRemoveStudent(StudentManager manager)
        {
            Console.Write("Nhập ID sinh viên cần xóa: ");
            string id = Console.ReadLine()!; // Dùng !
            
            if (manager.RemoveStudent(id)) { /* ... */ } else { /* ... */ }
        }

        static void HandleUpdateScore(StudentManager manager)
        {
            Console.Write("Nhập ID sinh viên cần cập nhật điểm: ");
            string id = Console.ReadLine()!; // Dùng !
            Console.Write("Nhập Điểm mới (0-10): ");
            string scoreInput = Console.ReadLine()!; // Dùng !

            try
            {
                double newScore = Convert.ToDouble(scoreInput);
                if (manager.UpdateScore(id, newScore)) { /* ... */ } else { /* ... */ }
            }
            catch (Exception ex) { Console.WriteLine($"\n🛑 Lỗi: {ex.Message}"); }
        }
        
        static void HandleFindStudent(StudentManager manager)
        {
            Console.Write("Nhập ID sinh viên cần tìm: ");
            string id = Console.ReadLine()!; // Dùng !

            // SỬA: Khai báo Student?
            Student? foundStudent = manager.FindStudentById(id); 

            if (foundStudent != null)
            {
                Console.WriteLine("\n⭐ Đã tìm thấy sinh viên:");
                foundStudent.Display();
            }
            else
            {
                Console.WriteLine($"❌ Không tìm thấy sinh viên ID '{id}'.");
            }
        }
    }
}