using (var client = new HttpClient())
{
    client.BaseAddress = new Uri("https://datctema20221029173655.azurewebsites.net/");
    //HTTP GET
    var countStudentsTask = await client.GetAsync("students/count");

    if (countStudentsTask.IsSuccessStatusCode)
    {
        var countStudents = await countStudentsTask.Content.ReadAsAsync<int>();

        var postCount = await client.PostAsJsonAsync("/metric", countStudents);

        Console.WriteLine(postCount.StatusCode);
    }
}
