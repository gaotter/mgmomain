const fs = require("fs/promises");

async function buildHtml() {
  const subDir = "src";
  const componentDir = "components";
  const dirs = await fs.readdir(`./${subDir}`);

  dirs
    .filter((dir) => dir.includes(".html"))
    .forEach(async (dir) => {
      const htmlFile = await fs.readFile(`./${subDir}/${dir}`, "utf8");

      // regex match {{anytext}} tags
      const tags = htmlFile.match(/{{.+}}/g);

      if (tags) {
        var updatedHtmlFile = htmlFile;
        tags.forEach(async (tag) => {
          const componentName = tag.replace(/{{|}}/g, "");
          const component = await fs.readFile(
            `./${subDir}/${componentDir}/${componentName}.html`,
            "utf8"
          );
          updatedHtmlFile = updatedHtmlFile.replace(tag, component);

          // save updated html file to dist folder
          await fs.writeFile(`./dist/${dir}`, updatedHtmlFile, "utf8");
        });
      }
    });
}

buildHtml();
console.log("Build complete");
