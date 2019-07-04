#!/bin/sh
protoc -I ./protos --csharp_out=./grpc --plugin=protoc-gen-grpc=`which grpc_csharp_plugin` ./protos/*.proto
