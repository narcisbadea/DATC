using (var client = new HttpClient())
{
    client.BaseAddress = new Uri("https://datctema20221029173655.azurewebsites.net/");

    var countStudentsTask = await client.GetAsync("students/count");

    if (countStudentsTask.IsSuccessStatusCode)
    {
        var countStudents = await countStudentsTask.Content.ReadAsAsync<int>();

        var postCount = await client.PostAsJsonAsync("/metric", countStudents);
        if (postCount.IsSuccessStatusCode)
        {

            Console.WriteLine($"Metric posted: {countStudents} students");
        }
        else
        {
            Console.WriteLine("Error at post metric!");
        }
    }
    else
    {
        Console.WriteLine("Error at request metric!");
    }
}
