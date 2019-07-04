#!/bin/sh
docker build -t yamltoprotobuf .
docker run -it -v `pwd`/out:/app/out yamltoprotobuf
