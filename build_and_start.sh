#!/bin/bash

# Check if the podman daemon is running
if ! podman info >/dev/null 2>&1; then
    echo "podman daemon is not running. Please start podman before running this script."
    exit 1
fi

# Remove previous image (if it exists)
podman rmi -f organizer-tmp

# Check if both solution name and version number are provided as command line arguments
if [ $# -ne 2 ]; then
    # Set default container name
    container_name="organizer-tmp"
else
    # Set the name of the solution and version number from the command line arguments
    solution_name="$1"
    version_number="$2"

    # Set the name of the container with the version number appended
    container_name="${solution_name}v${version_number}"
fi

# Build the podman container
podman build -t "${container_name}" .

# Start the podman container
podman run -it --rm -p 8080:80 "${container_name}"

# Manually run a debug session
# dotnet run --project ./Server/ -c Debug -v diag
