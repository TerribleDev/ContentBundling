namespace :files do
	task :clean_artifacts do
		puts 'Deleting all build artifacts from src/**/bin and src/**/obj. Removing output directory.'
		
		
		FileUtils.rm_r Dir.glob("src/**/bin")
		FileUtils.rm_r Dir.glob("src/**/obj")
	end
end