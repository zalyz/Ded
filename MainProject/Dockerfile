FROM openjdk:8-jdk-alpine
ARG JAR_FILE=*.jar
COPY airport-0.0.1-SNAPSHOT.jar airport.jar
ENTRYPOINT ["java","-jar","/airport.jar"]