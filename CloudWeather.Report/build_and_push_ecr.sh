#!/bin/bash
set -e

aws ecr get-login-password --region us-west-2 --profile weather-ecr-agent | docker login --username AWS --password-stdin 986361529537.dkr.ecr.us-west-2.amazonaws.com
docker build -f ./Dockerfile -t cloud-weather-report:latest .
docker tag cloud-weather-report:latest 986361529537.dkr.ecr.us-west-2.amazonaws.com/cloud-weather-report:latest
docker push 986361529537.dkr.ecr.us-west-2.amazonaws.com/cloud-weather-report:latest