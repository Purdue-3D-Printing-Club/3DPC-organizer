#!/bin/bash

# Check if the podman daemon is running
if ! podman info >/dev/null 2>&1; then
    echo "podman daemon is not running. Please start podman before running this script."
    exit 1
fi

container_name="3dpc-organizer-v2.0.0"

# Remove previous image (if it exists)
podman rmi -f ${container_name}


./Scripts/build.sh ${container_name}
./Scripts/run.sh ${container_name}