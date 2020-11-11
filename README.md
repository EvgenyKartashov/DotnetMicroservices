# DotnetMicroservices project

### Docker-compose settings:
```yaml
  active:
    image: masstransit/activemq:latest
    container_name: activemq
    hostname: activemq
    ports:
      - 8161:8161
      - 61616:61616	  
  rabbit:
    image: masstransit/rabbitmq
    container_name: rabbitmq
    ports:
     - 5672:5672
     - 15672:15672
```