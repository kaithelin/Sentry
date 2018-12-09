#!/bin/bash
cd ../..
docker build -t dolittle/sentry-gateway-backend -f Source/Gateway/Dockerfile.backend .
docker build -t dolittle/sentry-gateway-frontend -f Source/Gateway/Dockerfile.frontend .
cd Source/Gateway