const env = process.env.NODE_ENV;
const path = require('path');
const webpack = require('webpack');
const HtmlWebPackPlugin = require('html-webpack-plugin');
const ExtractTextPlugin = require('extract-text-webpack-plugin');

module.exports = {
    mode: 'development',
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
                //unused?
                test: /\.css$ /,
                use: [ 'style-loader','css- loader' ]
            },
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
                use: { loader: 'html-loader' }
            },
            {
                test: /\.(jpg|png|woff|woff2|eot|ttf|svg)$/,
                loader: 'url-loader?limit=100000'
            }
        ]
    },
    plugins: [
        new webpack.DefinePlugin({
            BLOG_API: JSON.stringify('http://localhost:58830')
        }),
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery',
            'window.jQuery': 'jquery',
            Popper: ['popper.js', 'default']
        }),
        new ExtractTextPlugin(
            { filename: 'style.bundle.css', disable: false, allChunks: true }
        ),
        new HtmlWebPackPlugin({
            inject: false,
            hash: true,
            template: './Views/Home/index.cshtml',
            filename: 'index.html'
        })
    ]
};