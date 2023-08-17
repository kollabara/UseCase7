using UseCase7.Entities;
using UseCase7.Helpers;

namespace UseCase7.Tests;

public class StudentConverterTests
{
    private readonly StudentConverter _studentConverter;

    public StudentConverterTests()
    {
        _studentConverter = new StudentConverter();
    }

    [Fact]
    public void ConvertStudents_HighAchiever_ReturnsHonorRollStudent()
    {
        var students = new List<Student>
        {
            new() { Name = "John", Age = 22, Grade = 95 }
        };

        var convertedStudents = _studentConverter.ConvertStudents(students);

        Assert.True(convertedStudents.Single().HonorRoll);
    }

    [Fact]
    public void ConvertStudents_ExceptionalYoungHighAchiever_ReturnsExceptionalStudent()
    {
        var students = new List<Student>
        {
            new() { Name = "Jane", Age = 20, Grade = 95 }
        };

        var convertedStudents = _studentConverter.ConvertStudents(students);

        Assert.True(convertedStudents.Single().Exceptional);
    }

    [Fact]
    public void ConvertStudents_PassedStudent_ReturnsPassedStudent()
    {
        var students = new List<Student>
        {
            new() { Name = "Alice", Age = 18, Grade = 80 }
        };

        var convertedStudents = _studentConverter.ConvertStudents(students);

        Assert.True(convertedStudents.Single().Passed);
    }

    [Fact]
    public void ConvertStudents_FailedStudent_ReturnsFailedStudent()
    {
        var students = new List<Student>
        {
            new() { Name = "Bob", Age = 19, Grade = 60 }
        };

        var convertedStudents = _studentConverter.ConvertStudents(students);

        Assert.False(convertedStudents.Single().Passed);
    }
    
    [Fact]
    public void ConvertStudents_EmptyArray_ReturnsEmptyArray()
    {
        var students = new List<Student>();

        var convertedStudents = _studentConverter.ConvertStudents(students);

        Assert.Empty(convertedStudents);
    }

    [Fact]
    public void ConvertStudents_NullArray_ThrowsArgumentNullException()
    {
        List<Student> students = null!;

        Assert.Throws<ArgumentNullException>(() => _studentConverter.ConvertStudents(students));
    }
}