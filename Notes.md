- Design
    Kept the design of the API to similar projects I worked on previously.
    Wanted to keep to SOLID principals but may have gone a little over board.
    Prefer utilizing EF when dealing with the database.
    Using Automapper where possible.
    Went with the code first apporach.
- Thoughts
    - Challenges
        Since this was the first time implementing RabbitMQ I did the best with the time I had.
        Had to add TrustServerCertificate=true to the connection string.
        Was not able to handle the load initial load at 500 because it blocked the API.
    - Improvements
        Decouple the code further.
        Double check current validation.
        Add the appropriate logging.
        Optimize further to handle load test.
        Have the Player inherit from IdentityUser but decided against it due to time.
- Extras
    The database will be created automatically on startup of App.
    Really enjoyed the assessment and learing about RabbitMQ.
- Powershells
    - App
        cd .\App\
        dotnet watch run
    - Consumer
        cd .\Consumer\
        dotnet watch run
    - Tester
        cd .\test\OT.Assessment.Tester\
        dotnet watch run
