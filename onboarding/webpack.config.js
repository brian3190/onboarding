const env = process.env.NODE_ENV;
const path = require('path');

module.exports = {
    mode: 'development',
    context: __dirname,
    entry: {
        app: './Scripts/react/index.js' 
    },
    output: {
        filename: '[name].bundle.js',
        path: path.resolve(__dirname, 'wwwroot/dist'),
        chunkFilename: '[name].bundle.js',
        publicPath: 'wwwroot/'
    },
    watch: true,
    resolve: {
        extensions: ['.js', '.jsx']
    },
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /(node_modules)/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['babel-preset-env', 'babel-preset-react'],
                        plugins: ["transform-class-properties"]
                    }
                }
            },
            {
                test: /\.jsx?$/,
                include: /(node_modules)/,
                use: ['react-hot-loader/webpack'],
            },
            {
                test: /\.html$/,
                use: { loader: "html-loader" }
            }
        ]
    }
};