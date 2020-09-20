nm=$(ls -A ./node_modules/*)
if [ -z "$nm" ]; then
    echo "installing dependencies..."
    npm install
fi
echo "starting client..."
npm start