#!/bin/bash

# Check if the Docker daemon is running
if ! docker info >/dev/null 2>&1; then
    echo "Docker daemon is not running. Please start Docker before running this script."
    exit 1
fi

# Check if both solution name and version number are provided as command line arguments
if [ $# -ne 2 ]; then
    echo "Please provide the solution name and version number as command line arguments."
    exit 1
fi

# Set the name of the solution and version number from the command line arguments
solution_name="$1"
version_number="$2"

# Set the name of the container with the version number appended
container_name="${solution_name}-${version_number}"

# Build the Docker container
docker build -t "${container_name}" .
