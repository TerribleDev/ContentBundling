require 'albacore'
require 'open-uri'
require 'fileutils'
require 'os'
require 'nokogiri'
import 'assets/rake/tools.rb'
import 'assets/rake/build.rb'
import 'assets/rake/test.rb'
import 'assets/rake/files.rb'

BUILD_CONFIG = (ARGV.include?('preflight') || ARGV.include?('fly')) ? 'Release' : (ENV['BUILD_CONFIG'] || 'Debug')
PACKAGES = File.expand_path("packages")
TOOLS = File.expand_path("tools")
NUGET = File.expand_path("#{TOOLS}/NuGet")
NUNIT = File.expand_path("#{PACKAGES}/NUnit.Runners.2.6.3/tools")


#<runnable tasks>

desc 'Bootstrap, fetch, build, test'
task :preflight => [:nuget, :build, :test ]
desc 'Bootstrap, fetch, build, test,'

desc 'Build the whole solution'
task :build do
	# Use msbuild in .net and xbuild in mono
	if OS.windows?
		Rake::Task["build:net_clean"].execute
		Rake::Task["build:net_build"].execute
	else
		Rake::Task["build:mon_clean"].execute
		Rake::Task["build:mon_build"].execute
	end
end

desc 'Clean build artifacts'
task :clean => ["files:clean_artifacts"]

desc 'Retrieve nuget dependencies'
task :nuget => ["tools:nuget_fetch"]

desc 'Run the unit tests'
task :test => "test:unit_tests"

