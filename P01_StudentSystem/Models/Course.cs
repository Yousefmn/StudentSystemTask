using P01_StudentSystem.Models;

public class Course
{
    public int CourseId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public ICollection<Resource> Resources { get; set; }

    public ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }

}