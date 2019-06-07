require("ignore-styles");

require("@babel/register")({
    ignore: [/(node_modules)/],
    presets: [
        [
            require.resolve("@babel/preset-env"),
            { targets: { node: "current" }, useBuiltIns: "entry" }
        ],
        require.resolve("@babel/preset-react")
    ],
    plugins: [
        require.resolve("@babel/plugin-proposal-class-properties"),
        [
            require.resolve("babel-plugin-styled-components"),
            {
                "ssr": true
            }
        ],
        require.resolve("@babel/plugin-syntax-dynamic-import"),
    ]
});

const prerenderer = require("./index").default;

module.exports = prerenderer;
