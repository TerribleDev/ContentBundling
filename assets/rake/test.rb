namespace :test do
	# Run unit tests with nunit
	nunit :unit_tests do |cmd|
		cmd.command = "#{NUNIT}/nunit-console.exe"
		cmd.assemblies = FileList[Dir.glob("src/*.UnitTest/bin/#{BUILD_CONFIG}/*UnitTest.dll")]
		#cmd.result_path = "output/tests"
		#cmd.no_logo
	end
end