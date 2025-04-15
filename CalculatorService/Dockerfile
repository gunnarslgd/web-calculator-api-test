# Use Amazon Linux as the base image
FROM amazonlinux:2

# Update the package manager and install Python, net-tools, and curl
RUN yum update -y && \
    yum install -y python3 net-tools curl
	
	
# Set the working directory inside the container
WORKDIR /usr/src/app

# Create index.html dynamically
RUN echo '<html>' > index.html && \
    echo '    <head>' >> index.html && \
    echo '        <title>IP Addresses</title>' >> index.html && \
    echo '    </head>' >> index.html && \
    echo '    <body>' >> index.html && \
    echo '        <h1>IP Address Information</h1>' >> index.html && \
    echo '        <p>Your IP Address: <span id="client-ip"></span></p>' >> index.html && \
    echo '        <p>Host IP Address: <span id="host-ip"></span></p>' >> index.html && \
    echo '        <script>' >> index.html && \
    echo '            document.getElementById("client-ip").innerText = window.location.hostname;' >> index.html && \
    echo '            fetch("/api/host-ip")' >> index.html && \
    echo '                .then(response => response.text())' >> index.html && \
    echo '                .then(data => document.getElementById("host-ip").innerText = data);' >> index.html && \
    echo '        </script>' >> index.html && \
    echo '    </body>' >> index.html && \
    echo '</html>' >> index.html

# Expose the port that the app will run on
EXPOSE 80

# Command to run the HTTP server
CMD ["python3", "-m", "http.server", "80"]