# Queue (rabbitmq)
Messaging Service Bus (MBS) is implemented with rabbitmq.  
It is using the rabbitmq alpine image with management enabled to reduce the size of the image. Then MQTT is enabled manually for inspiration on how to configure this image.
## Run 
Run ```docker-compose up``` to run the queue.

## Features
MQTT & AMQP is messaging protocols which both are enabled in this setup. 
### MQTT
Port: 1883
### AMQP
Port: 5672 
### Management UI
port: 15672
Go to "container-ip:15672" to see the management UI and login with the user provided in the .env file.

### Environments
Look at the .env.template for inspiration on how to configure the image

## Resources
https://zgadzaj.com/development/docker/docker-compose/containers/rabbitmq

https://hub.docker.com/_/rabbitmq

https://www.rabbitmq.com/documentation.html