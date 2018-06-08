build-app:
	@docker build --rm --network=host --build-arg version=$(VERSION) -t versioning .
.PHONY: build-app

run-app: build-app
	@docker run --rm -it versioning
.PHONY: build-app