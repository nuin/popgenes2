import * as d3 from 'd3';

export function runDriftSimulation(
  numPopulations: number,
  populationSize: number,
  initialFrequency: number,
  numGenerations: number
) {
  const results = [];

  for (let i = 0; i < numPopulations; i++) {
    const populationHistory = [{ generation: 0, frequency: initialFrequency }];
    let currentFrequency = initialFrequency;

    for (let j = 1; j <= numGenerations; j++) {
      if (currentFrequency > 0 && currentFrequency < 1) {
        const numAlleles = 2 * populationSize;
        const numAAlleles = d3.randomBinomial(numAlleles, currentFrequency)();
        currentFrequency = numAAlleles / numAlleles;
      }
      populationHistory.push({ generation: j, frequency: currentFrequency });
    }
    results.push(populationHistory);
  }

  return results;
}

export function drawChart(data: any[], numGenerations: number) {
  const container = d3.select("#chart-container");
  container.selectAll("*").remove();

  const margin = { top: 20, right: 30, bottom: 50, left: 60 };
  const width = 800 - margin.left - margin.right;
  const height = 400 - margin.top - margin.bottom;

  const svg = container
    .append("svg")
    .attr("width", width + margin.left + margin.right)
    .attr("height", height + margin.top + margin.bottom)
    .append("g")
    .attr("transform", `translate(${margin.left},${margin.top})`);

  const x = d3.scaleLinear().domain([0, numGenerations]).range([0, width]);
  const y = d3.scaleLinear().domain([0, 1]).range([height, 0]);

  const color = d3.scaleSequential(d3.interpolateTurbo).domain([0, data.length]);

  svg.append("g")
    .attr("transform", `translate(0,${height})`)
    .call(d3.axisBottom(x));

  svg.append("g").call(d3.axisLeft(y));

  const line = d3.line<{ generation: number, frequency: number }>()
    .x(d => x(d.generation))
    .y(d => y(d.frequency));

  const paths = svg.selectAll(".line")
    .data(data)
    .enter()
    .append("path")
    .attr("class", "line")
    .attr("d", line)
    .style("fill", "none")
    .style("stroke", (d, i) => color(i))
    .style("stroke-width", "2px")
    .style("opacity", 0.7);

  paths.each(function() {
    const path = d3.select(this);
    const totalLength = (path.node() as SVGPathElement).getTotalLength();
    path
      .attr("stroke-dasharray", `${totalLength} ${totalLength}`)
      .attr("stroke-dashoffset", totalLength)
      .transition()
      .duration(2000)
      .attr("stroke-dashoffset", 0);
  });

  svg.append("text")
    .attr("text-anchor", "middle")
    .attr("x", width / 2)
    .attr("y", height + margin.bottom - 10)
    .text("Generations");

  svg.append("text")
    .attr("text-anchor", "middle")
    .attr("transform", "rotate(-90)")
    .attr("y", -margin.left + 20)
    .attr("x", -height / 2)
    .text("Allele Frequency");
}