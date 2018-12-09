#!/bin/bash
docker push dolittle/sentry-gateway-backend
docker push dolittle/sentry-gateway-frontend
kubectl patch deployment sentry-gateway --namespace dolittle -p "{\"spec\":{\"template\":{\"metadata\":{\"labels\":{\"date\":\"`date +'%s'`\"}}}}}"

docker push dolittle/sentry-studio-backend
docker push dolittle/sentry-studio-frontend
kubectl patch deployment sentry-gateway --namespace dolittle -p "{\"spec\":{\"template\":{\"metadata\":{\"labels\":{\"date\":\"`date +'%s'`\"}}}}}"
