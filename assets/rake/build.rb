namespace :build do
	# Build the solution
	msbuild :net_build do |b|
		b.verbosity = 'normal'
		b.solution = "tparnell.ContentBundling.sln"
		b.properties = { :Configuration => BUILD_CONFIG }
	end

	xbuild :mon_build do |b|
		b.verbosity = 'normal'
		b.solution = "tparnell.ContentBundling.sln"
		b.properties = { :Configuration => BUILD_CONFIG }
	end

	# Clean the solution
	msbuild :net_clean do |b|
		b.verbosity = 'normal'
		b.solution = "tparnell.ContentBundling.sln"
		b.targets = [:Clean]
	end

	xbuild :mon_clean do |b|
		b.verbosity = 'normal'
		b.solution = 'tparnell.ContentBundling.sln'
		b.targets = [:Clean]
	end
end