package kmeans;

import java.io.IOException;
import java.util.concurrent.ThreadLocalRandom;

import org.apache.hadoop.io.LongWritable;
import org.apache.hadoop.mapreduce.Reducer;

public class KCombiner extends Reducer<LongWritable, PointWritable, LongWritable, PointWritable> {

	public void reduce(LongWritable centroidId, Iterable<PointWritable> points, Context context)
			throws IOException, InterruptedException {
		PointWritable ptSum = PointWritable.copy(points.iterator().next());
		while (points.iterator().hasNext()) {
			ptSum.sum(points.iterator().next());
		}
		context.write(centroidId, ptSum);
	}

	public static void main(String[] args) {
		for (int i = 0; i < 600; i++) {
			int n1 = ThreadLocalRandom.current().nextInt(300, 800);
			int n2 = ThreadLocalRandom.current().nextInt(300, 800);
			System.out.println(String.valueOf(n1) + ',' + String.valueOf(n2));
		}
	}
}
