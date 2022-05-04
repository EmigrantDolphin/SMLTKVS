#!/bin/bash

addCommand=add
updateCommand=update
removeCommand=remove

authContext=authentication

context=$1
myCommand=$2
name=$3

if [ -z "$1" ]
then
  echo ___HELP___
  echo "./migration.sh <context> <command> [name]"
  echo contexts: $authContext
  echo commands: $addCommand, $updateCommand, $removeCommand
  exit 0
fi

#add comand
if [ $myCommand == $addCommand ]
then
  if [ $context == $authContext ]
  then
    dotnet ef migrations add $name --startup-project WebApi/ --project BoundedContexts/Authentication/Authentication.Persistence --context authenticationContext
    exit 0
  fi
fi

#remove command
if [ $myCommand == $removeCommand ]
then
  if [ $context == $authContext ]
  then
    dotnet ef migrations remove --startup-project WebApi/ --project BoundedContexts/Authentication/Authentication.Persistence --context authenticationContext
    exit 0
  fi
fi

#update command
if [ $myCommand == $updateCommand ]
then
  if [ $context == $authContext ]
  then
    dotnet ef database update --startup-project WebApi/ --project BoundedContexts/Authentication/Authentication.Persistence --context authenticationContext
    exit 0
  fi
fi
