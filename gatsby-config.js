module.exports = {
  siteMetadata: {
    title: `Gatsby Default Starter`,
    description: `Kick off your next, great Gatsby project with this default starter. This barebones starter ships with the main Gatsby configuration files you might need.`,
    author: `@gatsbyjs`,
  },
  plugins: [
    `gatsby-plugin-react-helmet`,
    {
      resolve: `gatsby-source-filesystem`,
      options: {
        name: `images`,
        path: `${__dirname}/src/images`,
      },
    },
    `gatsby-transformer-sharp`,
    `gatsby-plugin-sharp`,
    {
      resolve: `gatsby-plugin-manifest`,
      options: {
        name: `gatsby-starter-default`,
        short_name: `starter`,
        start_url: `/`,
        background_color: `#663399`,
        theme_color: `#663399`,
        display: `minimal-ui`,
        icon: `src/images/gatsby-icon.png`, // This path is relative to the root of the site.
      },
    },
    {
      resolve: "gatsby-source-custom-api",
      options: {
        url: "https://dog.ceo/api/breeds/image/random",
        rootKey: "dogs",
        options: {
          schemas: {
            message: String,
            status: String,
          },
        },
      },
    },
    {
      resolve: "gatsby-source-custom-api",
      options: {
        url:
          "https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/volvo?format=json",
        rootKey: "cars",
        options: {
          schemas: {
            Count: Number,
            Message: String,
            SearchCriteria: String,
            Results: {
              Make_ID: Number,
              Make_Name: String,
              Model_ID: Number,
              Model_Name: String,
            },
          },
        },
      },
    },
    // this (optional) plugin enables Progressive Web App + Offline functionality
    // To learn more, visit: https://gatsby.dev/offline
    // `gatsby-plugin-offline`,
  ],
}
