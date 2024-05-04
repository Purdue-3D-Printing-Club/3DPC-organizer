#!/bin/bash

mkdir -p ./Server/Database/db
touch ./Server/Database/db/organizer.db

cd ./Server
dotnet ef database update

cd ..
cp ./Server/Database/db/organizer.db ./Scripts/organizer.db