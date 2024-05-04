#!/bin/bash

# Check if the podman daemon is running
if ! podman info >/dev/null 2>&1; then
    echo "podman daemon is not running. Please start podman before running this script."
    exit 1
fi

# Check if both solution name and version number are provided as command line arguments
if [ $# -ne 1 ]; then
    echo "Please provide the container name as command line arguments."
    exit 1
fi

# Set the name of the container with the version number appended
container_name="$1"

# Start the podman container
podman run -it --publish 9998:9998  --volume 3dpc-org-db:/3dpc-org-db/ "${container_name}"
