# RabbitMQ Tutorial project

[RabbitMQ Tutorial](https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html)

## Steps:

1. run `docker-composer up -d` to wind up the RabbitMQ server
2. open 2 terminals

in the first terminal

3. run `cd Receive`
4. run `dotnet run`

in the second terminal

5. run `cd Send`
6. run `dotnet run`

Open the browser on [http://localhost:15672](http://localhost:15672) with the default credentials `guest:guest`. To see what's going on.