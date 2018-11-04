#!/bin/bash

function create_test_project {
    PROJNAME=$1
    SUBNAME=$2
    ADD_PROJ_REF=$3

    mkdir "$PROJNAME.$SUBNAME"
    cd "$PROJNAME.$SUBNAME"
    dotnet new mstest
    dotnet remove package MSTest.TestFramework
    dotnet remove package MSTest.TestAdapter
    dotnet add package NUnit
    dotnet add package NUnit3TestAdapter
    if [ ADD_PROJ_REF == true ]; then
        dotnet add reference "../../src/$PROJNAME/$PROJNAME.csproj"
    fi
    cd ..
}

# declare globals
PROJNAME=$1
CREATE_ROOT="true"

# parse options
for i in "$@"
do
case $i in
    -r=*|--create-root-dir=*)
    CREATE_ROOT="${i#*=}"
    shift
    ;;
esac
done

if [ $CREATE_ROOT == "true" ]; then
    mkdir "$PROJNAME"
    cd "$PROJNAME"
fi

mkdir "src"
cd "src"
mkdir "$PROJNAME"
cd "$PROJNAME"
dotnet new webapi

cd ../..
mkdir "tests"
cd "tests"

create_test_project $PROJNAME "UnitTests" true
create_test_project $PROJNAME "IntegrationTests" true
create_test_project $PROJNAME "SmokeTests" false
