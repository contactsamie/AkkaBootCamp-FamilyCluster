#friend

FROM microsoft/aspnet

RUN apt-get update && apt-get install mono-4.0-service -y

RUN mkdir -p /app
COPY . /app
 
WORKDIR /app
CMD [ "mono",  "./FamilyCluster.FamilyFriend.exe" ]
 
EXPOSE 30000