namespace TestProject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void TestWorking()  //проверка алгоритма на работу
    {
        TimeSpan[] startTimes = 
        {
            new (10, 0, 0),
            new (11, 0, 0),
            new (15, 0, 0),
            new (15, 30, 0),
            new (16, 50, 0),
        };

        int[] durations = 
        {
            60,
            30,
            10,
            10,
            40
        };

        TimeSpan beginWorkingTime = new (8, 0, 0);
        TimeSpan endWorkingTime = new (18, 0, 0);
        int consultationTime = 30;

        CalculationsLib.Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
        Assert.Pass();
    }
    
    [Test]
    public void Test2() // Проверка на разницу в количестве между startTimes и durations
    {
        TimeSpan[] startTimes = 
        {
            new (10, 0, 0),
            new (11, 0, 0),
            new (15, 0, 0),
            new (15, 30, 0),
            new (16, 50, 0),
        };

        int[] durations = 
        {
            60,
            30,
            10,
            10,
        };

        TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
        TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
        int consultationTime = 30;

        try
        {
            CalculationsLib.Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
        }
        catch (Exception e)
        {
            Assert.AreEqual("Invalid startTimes and durations", e.Message);
            return;
        }
        
        Assert.Fail();
    }
    
    [Test]
    public void Test3() // Проверка на отрицательное время во времени консультации
    {
        TimeSpan[] startTimes = 
        {
            new (10, 0, 0),
            new (11, 0, 0),
            new (15, 0, 0),
            new (15, 30, 0),
            new (16, 50, 0),
        };

        int[] durations = 
        {
            60,
            30,
            10,
            10,
        };

        TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
        TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
        int consultationTime = -50;

        try
        {
            CalculationsLib.Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
        }
        catch (Exception e)
        {
            Assert.AreEqual("Invalid consultationTime", e.Message);
            return;
        }
        
        Assert.Fail();
    }    
    [Test]
    public void Test4() // Проверка на раннее завершение рабочего времени относительно начального времени
    {
        TimeSpan[] startTimes = 
        {
            new (10, 0, 0),
            new (11, 0, 0),
            new (15, 0, 0),
            new (15, 30, 0),
            new (16, 50, 0),
        };

        int[] durations = 
        {
            60,
            30,
            10,
            10,
        };

        TimeSpan beginWorkingTime = new TimeSpan(18, 0, 0);
        TimeSpan endWorkingTime = new TimeSpan(8, 0, 0);
        int consultationTime = 30;

        try
        {
            CalculationsLib.Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
        }
        catch (Exception e)
        {
            Assert.AreEqual("Invalid endWorkingTime", e.Message);
            return;
        }
        
        Assert.Fail();
    }
}