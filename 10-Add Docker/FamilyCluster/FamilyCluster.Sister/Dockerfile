#sister

FROM microsoft/aspnet

RUN apt-get update && apt-get install mono-4.0-service -y

RUN mkdir -p /app
COPY . /app
 
WORKDIR /app
CMD [ "mono",  "./FamilyCluster.Sister.exe" ]
 
EXPOSE 10000