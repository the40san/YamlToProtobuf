#!/bin/sh
protoc -I ./protos --csharp_out=./generated_codes ./protos/*.proto
